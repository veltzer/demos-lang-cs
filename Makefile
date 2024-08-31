##############
# parameters #
##############
# do you want to show the commands executed ?
DO_MKDBG?=0
# should we depend on the Makefile itself?
DO_ALLDEP:=1


#############
# variables #
#############
SOURCES=$(shell find src -name "*.cs")
ALL:=out/build.stamp


########
# code #
########
# silent stuff
ifeq ($(DO_MKDBG),1)
Q:=
# we are not silent in this branch
else # DO_MKDBG
Q:=@
#.SILENT:
endif # DO_MKDBG

#########
# rules #
#########
.PHONY: all
all: $(ALL)
	@true

.PHONY: clean
clean:
	$(info doing [$@])
	$(Q)-rm -f $(ALL)

.PHONY: clean_hard
clean_hard:
	$(info doing [$@])
	$(Q)git clean -qffxd


.PHONY: clean_dotnet
clean_dotnet:
	$(info doing [$@])
	$(Q)dotnet clean


out/build.stamp: $(SOURCES)
	$(info doing [$@])
	$(Q)dotnet build --nologo --verbosity quiet
	$(Q)pymakehelper touch_mkdir $@

.PHONY: debug
debug:
	$(info SOURCES is $(SOURCES))
	$(info ALL is $(ALL))

############
# all deps #
############

ifeq ($(DO_ALLDEP),1)
.EXTRA_PREREQS+=$(foreach mk, ${MAKEFILE_LIST},$(abspath ${mk}))
endif # DO_ALLDEP
