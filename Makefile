##############
# parameters #
##############
# do you want to show the commands executed ?
DO_MKDBG?=0


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

out/build.stamp: $(SOURCES)
	$(info doing [$@])
	$(Q)dotnet build --nologo --verbosity quiet > /dev/null
	$(Q)pymakehelper touch_mkdir $@

.PHONY: clean_hard
clean_hard:
	$(info doing [$@])
	$(Q)git clean -qffxd

.PHONY: debug
debug:
	$(info SOURCES is $(SOURCES))
	$(info ALL is $(ALL))
